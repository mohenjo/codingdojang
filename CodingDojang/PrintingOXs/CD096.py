# python
inp = int(input())
lst = ["O" * (inp - x) + "X" * x for x in range(1, inp + 1)]
print("\n".join(lst))
