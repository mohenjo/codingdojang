# python 3.6
n = int(input())
#   : 완전수 리스트 =           : x가 약수의 합과 같을 경우        : 약수
b = [x for x in range(1, n + 1) if x == sum(i for i in range(1, x) if x % i == 0)]
print(b)
# ans for 10000: [6, 28, 496, 8128]
