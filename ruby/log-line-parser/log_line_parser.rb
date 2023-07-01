class LogLineParser
  def initialize(line)
    @line = line
  end

  def message
    @line.split(":")[1].strip
  end

  def log_level
    @line.split(":")[0].gsub(/[\[\]]/, "").downcase
  end

  def reformat
    "#{self.message} (#{self.log_level})"
  end
end
