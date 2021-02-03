using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Reactor
{
    private readonly IDictionary<int, Cell> _cells = new Dictionary<int, Cell>();

    public InputCell CreateInputCell(int value)
    {
        var cell = new InputCell(_cells.Count, value);
        cell.Changed += OnCellChanged;
        
        _cells[cell.Id] = cell;
        return cell;
    }

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        var cell = new ComputeCell(_cells.Count, producers.ToList(), compute);
        _cells[cell.Id] = cell;
        return cell;
    }

    private void OnCellChanged(object sender, int value)
    {
        var cell = (Cell)sender;
        var consumers = new BitArray(_cells.Count);
        
        foreach (var consumer in cell.Consumers)
        {
            consumers.Set(consumer.Id, true);
        }

        for (var id = cell.Id + 1; id < _cells.Count; id++)
        {
            if (!consumers.Get(id))
            {
                continue;
            }

            var consumer = (ComputeCell)_cells[id];
            consumer.Refresh();

            foreach (var transitiveConsumer in consumer.Consumers)
            {
                consumers.Set(transitiveConsumer.Id, true);
            }
        }
    }
}

public abstract class Cell
{
    protected Cell(int id)
    {
        Id = id;
        Consumers = new List<Cell>();
    }

    public int Id { get; }
    public List<Cell> Consumers { get; }

    public abstract int Value { get; set; }
}

public class InputCell : Cell
{
    private int _value;
    
    public InputCell(int id, int value) : base(id)
    {
        _value = value;
    }

    public event EventHandler<int> Changed;
    
    public override int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                Changed?.Invoke(this, value);
            }
        }
    }
}

public class ComputeCell : Cell
{
    private readonly Func<int> _refresher;
    private int _value;

    public ComputeCell(int id, IReadOnlyCollection<Cell> producers, Func<int[], int> compute) : base(id)
    {
        _refresher = () => compute.Invoke(producers.Select(p => p.Value).ToArray());

        foreach (var producer in producers)
        {
            producer.Consumers.Add(this);
        }
        
        _value = _refresher.Invoke();
    }

    public event EventHandler<int> Changed;
    
    public override int Value
    {
        get => _value; 
        set => throw new NotSupportedException("Can not set value of computed cell");
    }

    internal void Refresh()
    {
        var nextValue = _refresher.Invoke();

        if (_value != nextValue)
        {
            _value = nextValue;
            Changed?.Invoke(this, _value);
        }
    }
}