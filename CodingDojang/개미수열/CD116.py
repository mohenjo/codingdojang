# python 3.6


def las(string, limit):
    """string: 입력 수열, limit: 수열의 문자열 길이 제한"""
    seq = string
    while True:
        rst = seq[0]
        for i in range(1, len(seq)):
            if seq[i] != rst[-1]:
                rst += ","
            rst += seq[i]
        seq = "".join([str(len(s)) + s[0] for s in rst.split(",")])
        if len(seq) > limit:
            seq = seq[:limit]
        yield seq


# 문제, 도전 1
my_seq = las("1", 1000)  # sequence(1) (문자수 제한 = 1000)
for i in range(2, 1001):
    result = next(my_seq)  # sequence(2), ... seq(1000)
    if i == 100:
        print(i, result[i - 1])
    if i == 1000:
        print(i, result[i - 1])
# 도전 2
"""수열의 길이가 기하급수적으로 증가하므로
계산 시간 단축을 위해 999950번째 까지는 문자수를 10개로 제한,
이후 50개의 수열만 100만 자리까지로 계산"""
my_seq = las(result, 10)  # sequence(1000)에서 문자수 제한(= 10) 재 설정
for i in range(1001, 999951):
    result = next(my_seq)  # sequence(1001), ... seq(999950)
my_seq = las(result, 10**6)
for i in range(999951, 10 ** 6 + 1):  # sequence(999951), ..., seq(10**6)
    result = next(my_seq)
    if i == 10 ** 6:
        print(i, result[i - 1])
# ans:
# 100 1
# 1000 3
# 1000000 1