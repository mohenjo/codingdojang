# Josephus Permuation
동일 문제에 대해 Josephus Permutation을 적용하여 
풀 수도 있는데, Josephus Permuation은 다음과 같이 정의된다:

병사 수 n명(첫번 째 병사에 대해 n = 1), 간격 k이 주어질 때,
n과 k의 관계는 다음과 같다.

*f*(n, k) = {*f*(n - 1, k) + k - 1} % n + 1

*f*(1, k) = 1

    static int Josephus(int n, int k)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return (Josephus(n - 1, k) + k - 1) % n + 1;
            }
        }