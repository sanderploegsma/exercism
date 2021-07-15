class Matrix
  attr_reader :rows, :columns, :saddle_points

  def initialize(data)
    @rows = data.lines.map { |row| row.split.map(&:to_i) }
    @columns = rows.transpose
    @saddle_points = []

    (0..@rows.length - 1).each do |row|
      (0..@columns.length - 1).each do |col|
        value = @rows[row][col]
        @saddle_points.append([row, col]) if @rows[row].all? { |v| v <= value } && @columns[col].all? { |v| v >= value }
      end
    end
  end
end
