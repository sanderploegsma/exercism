(ns leap)

(defn leap-year? [year]
  (cond (= (mod year 400) 0) true
        (= (mod year 100) 0) false
        :else (= (mod year 4) 0)
    )
)
