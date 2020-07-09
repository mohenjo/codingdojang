# python 3.6
import itertools as it


def subsets(inp):
    """return the list of inp subsets for a given inp"""
    # 입력 문자열에 대해 길이 별 부분집합 문자(열) 생성(문자열 내 순서대로 포함 조건)
    return ["".join(tp) for i in range(len(inp) + 1)
            for tp in list(it.combinations(inp, i)) if "".join(tp) in inp]


st1 = input("string 1: ")
st2 = input("string 2: ")
# 부분 문자열으 교집합 중 최대 길이
cmn = max(set(subsets(st1)) & set(subsets(st2)))
print("%d\n%s" % (len(cmn), cmn))
