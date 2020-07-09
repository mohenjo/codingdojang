def main():
    p0, p1 = eval(input())
    xmin, xmax = min(p0[0], p1[0]), max(p0[0], p1[0])
    ymin, ymax = min(p0[1], p1[1]), max(p0[1], p1[1])
    rst = []
    if xmin != xmax:
        for x in range(xmin + 1, xmax):
            y = (p1[1] - p0[1]) / (p1[0] - p0[0]) * (x - p0[0]) + p0[1]
            if y == int(y):
                rst.append(str([x, int(y)]))
    else:  # y = const 직선인 경우
        for y in range(ymin + 1, ymax):
            rst.append(str([xmin, y]))

    print(", ".join(rst) if rst else None)


if __name__ == "__main__":
    main()
