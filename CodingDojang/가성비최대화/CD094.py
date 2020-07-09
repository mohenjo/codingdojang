# python 3.6
import itertools as it

ov = 10
op = 150
av = 3
ap = [30, 70, 15, 40, 65]

max_coeff = 0
for sel_num in range(1, len(ap) + 1):
    ap_gen = it.combinations(ap, sel_num)
    rept = True
    while rept:
        try:
            lst = next(ap_gen)
        except StopIteration:
            rept = False
        else:
            max_coeff = max(max_coeff, (sum(lst) + op) / (len(lst) * av + ov))
print(int(max_coeff))
