def main():
    _, num_reports = map(int, input().strip().split())
    reports = []  # 리포트 문자열 저장
    for _ in range(num_reports):
        reports.append(input().strip())

    relations = dict()  # 사전 - 신규 키(정치인) 성향(1)에 대한 상대적 성향(친구=1 | 적=-1)
    mismatch_num = 0  # 불일치 발생 보고의 회차
    for i, report in enumerate(reports):
        a, b, x = report.strip().split()  # a, b, x
        rel_stat = 1 if x == "f" else -1  # 친구 => 1, 적 => -1
        relations.setdefault(a, 1)  # a => 신규 정치인일 경우 성향(1)
        # b 정치인 성향 = a 정치인 성향 * (친구 = 1 | 적인 경우 = -1)
        relations.setdefault(b, relations[a] * rel_stat)  # b => 신규 정치인일 경우
        # 존재하는 b 키에 대해 새로 보고된 적아 구분(1 or -1)이 다를 경우
        if relations[a] * rel_stat != relations[b]:
            mismatch_num = i + 1
            break

    print(mismatch_num if mismatch_num > 0 else "THE SPY DID NOT BETRAY")


if __name__ == "__main__":
    main()
