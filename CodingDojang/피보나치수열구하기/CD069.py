# python 3.6
def fibo(n):
    x = 0
    y = 1
    ret = list()
    while x <= n:
        ret.append(x)
        x, y = y, x + y
    return ret


inp = int(input())
print(fibo(inp))
