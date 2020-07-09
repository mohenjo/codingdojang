prec = 2  # 숫점 이하 자리수(정확도)


def update_grid(posx1, posy1, posx2, posy2):
    new_grid = set()
    for y in range(int(posy1 * 10 ** prec), int(posy2 * 10 ** prec)):
        for x in range(int(posx1 * 10 ** prec), int(posx2 * 10 ** prec)):
            new_grid.add((x, y))
    return new_grid


def print_area(istr):
    grid = set()
    lines = istr.split('\n')
    for line in lines:
        grid |= update_grid(*map(float, line.split()))  # 좌표의 합집합
    print(f"{len(grid) / (10 ** (2 * prec)):.2f}")


# --- test cases ---

test_case = """0.0 0.0 4.0 4.0
1.0 1.0 3.0 3.0"""
print_area(test_case)  # 16.00

test_case = """1.0 0.0 5.0 2.0
2.0 0.0 4.0 5.0
0.0 1.0 6.0 3.0
10.0 10.0 12.0 12.0"""
print_area(test_case)  # 24.00

test_case = """1 2 4 4 
2 3 5 7 
3 1 6 5 
7 3 8 6"""  # Four Boxes 문제
print_area(test_case)  # 26.00
