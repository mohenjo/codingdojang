# python 3.6


def base_n(n, base):
    pool = "0123456789ABCDEF"
    rst = list()
    while n:
        rst.insert(0, pool[n % base])
        n = n // base
    return "".join(rst)


print(base_n(233, 2), base_n(233, 8), base_n(233, 16))
# ans: 11101001 351 E9