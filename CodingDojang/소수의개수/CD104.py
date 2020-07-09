# python 3.6
lst = [i for i in range(2, 1001)]

pnum = list()
while lst:
    pnum.append(min(lst))
    lst = [v for v in lst if v % min(lst) != 0]
print(len(pnum))
# ans: 168
