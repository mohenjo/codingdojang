# python 3.6
def fibo(n):
    x = 1
    y = 2
    ret = list()
    while x <= n:
        ret.append(x)
        x, y = y, x + y
    return ret


print(sum([i for i in fibo(4 * (10**6)) if i % 2 == 0]))
# ans: 4613732
