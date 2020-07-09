class HappyNum:
    def __init__(self, num: int):
        self.num = num
        self.pool = []  # 각 자리수 제곱의 합이 저장될 시퀀스

    def getstatstr(self):
        next_num = self.num
        while next_num not in self.pool:  # 시퀀스 내 숫자가 없으면
            self.pool.append(next_num)  # 추가 하고
            next_num = HappyNum._getnext(next_num)  # 다음 시퀀스 계산
        # 1인 경우 a happy 아니면 an unhappy
        return f"{self.num} is {'a Happy' if next_num == 1 else 'an Unhappy'} number."

    @staticmethod
    def _getnext(num: int):  # 숫자 -> 각 자리수 제곱의 합
        return sum(int(c) ** 2 for c in str(num))


def main():
    numcases = int(input())
    cases = [int(input()) for _ in range(numcases)]
    for i, v in enumerate(cases):
        case = HappyNum(v)
        print(f"Case #{i + 1}: {case.getstatstr()}")


if __name__ == "__main__":
    main()
