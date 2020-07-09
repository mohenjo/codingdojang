import itertools as it


def get_score(answer: int, guess: int):  # 스트라이크, 볼 개수 반환
    a_str, g_str = str(answer), str(guess)
    balls = len([g for g in g_str if g in a_str])
    strikes = len([g for i, g in enumerate(g_str) if a_str[i] == g])
    balls -= strikes
    return strikes, balls


def main():
    # 3 자리 수의 정답 풀을 만든 후
    ans_pool = [int("".join(lst)) for lst in it.permutations(str(123456789), 3)]

    num_inq = int(input())
    for _ in range(num_inq):
        guess, strikes, balls = map(int, input().strip().split())
        # 각 응답의 조건에 만족하는 경우만 남김
        ans_pool = [n for n in ans_pool if get_score(n, guess) == (strikes, balls)]

    print(f"{len(ans_pool)}: {ans_pool}")


if __name__ == "__main__":
    main()
