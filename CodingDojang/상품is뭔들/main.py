from fractions import Fraction

a, b = map(int, input().split())

# 홀수 개의 약수를 가지려면 항상 완전 제곱수
# 사례. (3, 10] 사이의 완전 제곱수는 (3**0.5, 10**0.5] = (1.xx, 3.xx] => 1개 (2)
# 즉, (a, b] 사이의 완전 제곱수의 개수는 다음과 같다.
count = int(b ** 0.5) - int(a ** 0.4)

# 기약분수표현
f = Fraction(count, b - a)
print(f"{f.numerator}/{f.denominator}")
