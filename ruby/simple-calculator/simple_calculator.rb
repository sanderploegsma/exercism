class SimpleCalculator
  ALLOWED_OPERATIONS = ['+', '/', '*'].freeze

  class UnsupportedOperation < StandardError
  end

  def self.calculate(first_operand, second_operand, operation)
    raise UnsupportedOperation unless ALLOWED_OPERATIONS.include? operation
    raise ArgumentError unless first_operand.kind_of?(Integer)
    raise ArgumentError unless second_operand.kind_of?(Integer)

    begin
      answer = first_operand.send(operation, second_operand)
      "#{first_operand} #{operation} #{second_operand} = #{answer}"
    rescue ZeroDivisionError
      "Division by zero is not allowed."
    end    
  end
end
