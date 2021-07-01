using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public Tree(int id)
    {
        Id = id;
        Children = new List<Tree>();
    }

    public int Id { get; }

    public List<Tree> Children { get; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    private const int RootRecordId = 0;

    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var subtrees = new List<Tree>();

        var expectedRecordId = RootRecordId;
        foreach (var record in records.OrderBy(r => r.RecordId))
        {
            ValidateRecord(record, expectedRecordId);

            subtrees.Add(new Tree(record.RecordId));

            if (!record.IsRoot())
            {
                subtrees[record.ParentId].Children.Add(subtrees[record.RecordId]);
            }

            expectedRecordId++;
        }

        if (subtrees.Count == 0)
        {
            throw new ArgumentException("Cannot build tree from empty records");
        }

        return subtrees[RootRecordId];
    }

    private static void ValidateRecord(TreeBuildingRecord record, int expectedRecordId)
    {
        if (record.RecordId != expectedRecordId)
        {
            throw new ArgumentException($"Record {record.RecordId} has invalid identifier");
        }

        if (record.IsRoot() && record.ParentId != record.RecordId)
        {
            throw new ArgumentException($"Root record {record.RecordId} has invalid parent identifier");
        }

        if (!record.IsRoot() && record.ParentId >= record.RecordId)
        {
            throw new ArgumentException($"Record {record.RecordId} has invalid parent identifier");
        }
    }

    private static bool IsRoot(this TreeBuildingRecord record) => record.RecordId == RootRecordId;
}