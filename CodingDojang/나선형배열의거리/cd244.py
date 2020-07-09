def main():
    num = int(input())
    rst = get_min_distance(num)
    print(rst)


def get_nth(num: int):
    """num이 속하는 범주(nth) 계산"""
    nth = 0
    last_val = 1
    while num > last_val:
        nth += 1
        last_val = (2 * (nth + 1) - 1) ** 2
        
    return nth


def get_min_distance(num: int):
    """num으로 이동하는 최소 거리 계산"""
    nth = get_nth(num)
    if num == 1:
        return nth

    points = [4 * nth ** 2 - 3 * nth + 1]
    for i in range(3):
        points.append(points[-1] + nth * 2)
    min_distance = nth + min(abs(num - point) for point in points)

    return min_distance


if __name__ == '__main__':
    main()
