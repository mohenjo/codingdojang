def gen_crosswords(word_a: str, word_b: str):
    # 교점 존재 여부 찾기
    foo = tuple(word_a.find(c) for c in word_b if word_a.find(c) != -1)
    if not len(foo):
        return
    # 교점 위치에 대한 각 문자열 내 인덱스
    idx_a, idx_b = foo[0], word_b.find(word_a[foo[0]])
    # 반환 문자 배열 생성
    result = ['.' * idx_a + v + '.' * (len(word_a) - idx_a - 1) for _, v in enumerate(word_b)]
    result[idx_b] = word_a
    return '\n'.join(result)


def main():
    words = input().split()
    result = gen_crosswords(words[0], words[1])
    print(result)


if __name__ == "__main__":
    main()
