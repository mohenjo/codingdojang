def _progress(num: int):  # num에 대해 2배, 리버스 계산 튜플 반환
    reversed_num = 1
    if num >= 10:
        strnum = str(num)
        strnum = strnum[-1] + strnum[1:-1] + strnum[0]
        reversed_num = int(strnum)
    return num * 2, reversed_num


def _find_routes(target: int):
    routes = {1: ""}
    while target not in routes:  # 목표 정수가 routes에 없을 경우
        tmpdic = {}
        for k in routes:  # routes 내 키(정수)에 대해 2배, 리버스 수행
            dbl, swp = _progress(k)
            if dbl not in routes and dbl not in tmpdic:
                tmpdic[dbl] = routes[k] + "D"
            if swp not in routes and swp not in tmpdic:
                tmpdic[swp] = routes[k] + "R"
        routes.update(tmpdic)  # 중복 키를 제외한 사전을 추가하여 routes 갱신
    return routes[target]


def get_routes(target):  # 1 -> num까지 도달하는 과정 출력
    routes = _find_routes(target)
    result = [1]
    for c in routes:
        # 'D': 2배, 'R': 리버스
        addval = result[-1] * 2 if c == "D" else _progress(result[-1])[1]
        result.append(addval)
    return "->".join(str(i) for i in result)


def main():
    result = get_routes(77)
    print(result)
    result = get_routes(757)
    print(result)


if __name__ == "__main__":
    main()
