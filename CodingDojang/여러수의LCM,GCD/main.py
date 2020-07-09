import functools


def gcd(a: int, b: int):
    a, b = max(a, b), min(a, b)
    while b:
        a, b = b, a % b
    return a


def lcm(a: int, b: int):
    return a * b // gcd(a, b)


def cds(num: int):
    return [x for x in range(1, num + 1) if num % x == 0]


input_list = [6015240, 1507968, 4530816]
result_gcd = functools.reduce(gcd, input_list)
result_lcm = functools.reduce(lcm, input_list)

print(f"GCD: {result_gcd}")
print(f"LCM: {result_lcm}")
print(f"Divisors: {cds(result_gcd)}")
