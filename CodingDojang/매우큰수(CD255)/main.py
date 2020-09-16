import itertools


class BigNum:
    """자연수 연산 클래스"""

    def __init__(self, num: str):
        self.numstr: str = num
        # 1의 자리부터의 계산을 위한 inversed string
        self.numstr_desc: str = self.numstr[::-1]

    def __mul__(self, other):
        """곱셈 연산자(*) 매직 메소드"""
        # 자리별 숫자의 곱셈 매칭을 위해 "0"으로 채운 zip
        desc_grp = list(itertools.zip_longest(
            self.numstr_desc, other.numstr_desc, fillvalue="0"))
        length = len(desc_grp)

        # 인덱스0 = 1의 자리의 곱셉값 저장, ..., 인덱스n = n자리의 곱셉값 저장
        rst = [0] * int(max(len(self.numstr), len(other.numstr)) * 2 + 1)
        # 각 자리수별로 숫자를 곱하고 곱셈값의 10의 자리는 다음 인덱스에 더함
        for idx1 in range(length):
            for idx2 in range(length):
                baseidx = idx1 + idx2
                digit_multi = int(desc_grp[idx2][0]) * int(desc_grp[idx1][1])
                for i, v in enumerate(d for d in str(digit_multi)[::-1]):
                    rst[baseidx + i] += int(v)

        # 각 자리별로 곱해진 결과 리스트 정리
        for idx in range(len(rst) - 1):
            if rst[idx] >= 10:
                rst[idx + 1] += (rst[idx] // 10)
                rst[idx] = rst[idx] % 10

        # 곱셈결과를 새로운 인스턴스로 반환
        return BigNum("".join(map(str, rst[::-1])).lstrip("0"))

    def __pow__(self, power, modulo=None):
        """거듭제곱 연산자(**) 매직 메소드"""
        # 거듭제곱 수만큼 곱셈 메소드 호출
        rst = self
        for _ in range(power - 1):
            rst = self.__mul__(rst)
        return rst

    def __str__(self):
        return self.numstr


if __name__ == '__main__':
    case1rst = BigNum("34566789") * BigNum("9989953") ** 5
    print(case1rst)
    # "3439349130987378995741000108452472269377477"

    case2rst = BigNum("242896") * BigNum("2345987") * BigNum("3948562") \
               * BigNum("2673851") * BigNum("2349863") * BigNum("2") \
               * BigNum("9873645") * BigNum("5728364")
    print(case2rst)
    # "1599200004322211514880952175873148802507070720"
