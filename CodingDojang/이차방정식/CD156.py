# python 3.6

def solEq(a, b, c):
    D = b**2 - 4*a*c # 판별식
    rst = None if D <0 else \
    set([round((-b + D**0.5) / (2*a)), round((-b - D**0.5) / (2*a))])
    return rst

def main():
    a, b, c = map(float, input("Input (a, b, c): ").split(","))
    rst = solEq(a, b, c)
    print("Solution:", rst)


if __name__=="__main__":
    main()