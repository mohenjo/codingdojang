import math 

def main():
    tries = int(input())
    rst = ""
    for retry in range(tries):
        case = list(map(int, input().split()))
        rst += f"{find_steplen(abs(case[0]-case[1]))}\n"
    print(rst)
    

# 숫자간의 거리 D, 스텝의 길이 SL라고 할 때,
# SL 1 2 3 4 5  6  7  8  9 10 ...
# D  1 2 4 6 9 12 16 20 25 30 ... 이므로,
# D = floor((SL+1)**2/4)의 관계를 갖는다.  https://oeis.org/A002620 수열 참조
def find_steplen(distance:int):
    step = 0
    est_dist = 0
    while distance > est_dist:
        step += 1
        est_dist = math.floor((step + 1) ** 2 / 4)
    return step

if __name__ == "__main__":
    main()
