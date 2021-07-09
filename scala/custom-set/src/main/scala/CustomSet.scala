object CustomSet {
  def fromList[T](list: List[T]): CustomSet[T] =
    CustomSet[T](list.distinct)

  def empty[T](set: CustomSet[T]): Boolean =
    set.items.isEmpty

  def member[T](set: CustomSet[T], item: T): Boolean =
    set.items.contains(item)

  def insert[T](set: CustomSet[T], item: T): CustomSet[T] =
    if (CustomSet.member(set, item)) set else CustomSet.fromList(item :: set.items)

  def intersection[T](set1: CustomSet[T], set2: CustomSet[T]): CustomSet[T] =
    CustomSet.fromList(set1.items.intersect(set2.items))

  def union[T](set1: CustomSet[T], set2: CustomSet[T]): CustomSet[T] =
    CustomSet.fromList(set1.items.union(set2.items))

  def difference[T](set1: CustomSet[T], set2: CustomSet[T]): CustomSet[T] =
    CustomSet.fromList(set1.items.diff(set2.items))

  def isSubsetOf[T](set1: CustomSet[T], set2: CustomSet[T]): Boolean =
    set1.items.forall { CustomSet.member(set2, _) }

  def isDisjointFrom[T](set1: CustomSet[T], set2: CustomSet[T]): Boolean =
    CustomSet.empty(CustomSet.intersection(set1, set2))

  def isEqual[T](set1: CustomSet[T], set2: CustomSet[T]): Boolean =
    CustomSet.isSubsetOf(set1, set2) && CustomSet.isSubsetOf(set2, set1)
}

case class CustomSet[+T](items: List[T])