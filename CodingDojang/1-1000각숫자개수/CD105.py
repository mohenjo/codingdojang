# python 3.6
# 각 숫자의 표시 횟수만큼 더해서 0개 이상인 경우 출력
for i in range(10):
    rst = sum([x.count(str(i)) for x in map(str, range(1, 1001))])
    if rst > 0:
        print("%d: %d" % (i, rst))

# ans:
# 0: 192
# 1: 301
# 2: 300
# 3: 300
# 4: 300
# 5: 300
# 6: 300
# 7: 300
# 8: 300
# 9: 300
