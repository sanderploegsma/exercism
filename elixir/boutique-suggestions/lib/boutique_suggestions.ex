defmodule BoutiqueSuggestions do
  @defaults [maximum_price: 100.0]

  def get_combinations(tops, bottoms, options \\ []) do
    opts = Keyword.merge(@defaults, options)

    for top <- tops,
        bottom <- bottoms,
        top.base_color != bottom.base_color,
        top.price + bottom.price <= opts[:maximum_price] do
      {top, bottom}
    end
  end
end
