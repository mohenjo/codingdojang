# python 3.6
import itertools as it

inp = [3, 30, 34, 5, 9]

pool = it.permutations(inp, len(inp))  # 비중복 순열 제너레이터 생성
rpt = True
max_val = 0
while rpt:
    try:
        lst = next(pool)
    except StopIteration:
        rpt = False
    else:
        max_val = max(max_val, int("".join(map(str, lst))))

print(max_val)
# ans: 9534330
