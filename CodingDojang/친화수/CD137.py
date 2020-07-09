# python 3.6
import math


def divsum(val):
    """val의 진약수 합 반환"""
    rst = set()
    for i in range(1, int(math.sqrt(val) + 1)):
        if val % i == 0:
            rst.update([i, val // i])
    return sum(rst) - val


def amicnum(val):
    """자연수 val에 대해 친화수가 존재할 경우 쌍 반환"""
    val1 = divsum(val)
    val2 = divsum(val1)
    if val2 == val and val != val1:
        return (val, val1)


num = int(input("Input a natural number: "))
amic_lst = list()
for i in range(1, num + 1):
    val = amicnum(i)
    if val is not None and max(val) <= num:
        amic_lst.append(val)
print(len(amic_lst) // 2, amic_lst)
