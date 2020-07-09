def main():
    max_p = 0
    max_count = 0
    for p in range(12, 1000 + 1):
        count = get_rtri_count(p)
        if count > max_count:
            max_count = count
            max_p = p
    print(f"max count = {max_count} at p = {max_p}")


# 직각 삼각형의 개수
def get_rtri_count(p):
    count = 0
    for a in range(3, p // 2 + 1):
        b = (2 * p * a - p ** 2) / (2 * a - 2 * p)
        c = (a ** 2 + b ** 2) ** 0.5
        if b == int(b) and c == int(c) and a <= b:
            count += 1
    return count


if __name__ == '__main__':
    main()
