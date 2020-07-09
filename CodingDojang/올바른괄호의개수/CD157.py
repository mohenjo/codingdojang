"""
Catalan number를 이용한 문제 해결
(0, 0)에서 (n, n)까지 격자점을 지나는 최단 거리의 경로 중에서 직선 y = x를 
넘지 않는 경우의 수
: y = x를 넘지 않음 ==> (), /\ are ok )(, \/ are ng.

Catalan Number, C(n) = (2n)! / {n!(n+1)!}
where, n int >= 0
"""

def factorial(n):
    rst = 1 if n==0 else n * factorial(n-1)
    return rst

def catNum(n):
    rst = int(factorial(2*n) / (factorial(n) * factorial(n+1)))
    return rst

def main():
    N = 5 # 괄호 쌍의 개수
    print(catNum(N))


if __name__=="__main__":
    main()

# catNum = 1, 2, 5, 14, 42, ... for N = 1, 2, 3, 4, 5, ...