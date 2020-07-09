# python 3.6
def factorial(val):
    if val == 0:
        return 1
    else:
        val = val * factorial(val - 1)
        return val


inp = 25
rst = list(str(factorial(inp)))
count = 0
while not int(rst.pop()):
    count += 1
print(count)
# ans for 25:
# 6
