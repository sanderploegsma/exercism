defmodule NameBadge do
  @owner "OWNER"
  @separator " - "

  def print(id, name, department) do
    id_s = if id, do: "[#{id}]"
    dep_s = if department, do: String.upcase(department), else: @owner

    [id_s, name, dep_s]
    |> Enum.reject(&is_nil/1)
    |> Enum.join(@separator)
  end
end
