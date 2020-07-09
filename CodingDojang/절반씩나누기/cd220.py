# 시퀀스 seq로부터 길이 length에 해당하는 조합(리스트의 리스트) 생성
def combination(seq, length):
    if length == 0:
        return [[]]
    return [[val] + lst for idx, val in enumerate(seq)
            for lst in combination(seq[idx + 1:], length - 1)]


# 절반씩 조합된 리스트의 쌍을 얻음
def get_halves(n_input: int):
    seq = range(n_input)
    length = len(seq) // 2
    result = []  # 전, 후 리스트 쌍

    firsts: list = combination(seq, length)  # 앞쪽 절반에 해당하는 리스트
    for first in firsts:
        result.append((first, [s for s in seq if s not in first]))

    return result


def main():
    n: int = int(input())
    rst = get_halves(n)

    for halves in rst:
        print(halves)


if __name__ == '__main__':
    main()
