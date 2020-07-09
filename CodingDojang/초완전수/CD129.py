def sum_ntps(n):  # = f(n)-n-1 = 진(proper)약수면서, 고유(non-trivial)약수의 합
    return sum({divs for i in range(2, int(n ** 0.5) + 1) if n % i == 0 for divs in (i, n // i)})


for n in range(1, int(input()) + 1):
    check = sum_ntps(n)
    if check == 0: continue
    # k 값이 자연수인 경우 결과 쌍 출력
    k = (n - 1) / check
    if k.is_integer(): print(f"({n},{int(k)}) ", end='')
