n, w, L = map(int, input().split())  # n: 트럭의 수, w: 다리의 길이, L: 다리의 최대 하중
tws = [int(s) for s in input().split()[:n]]  # 트럭의 무게 리스트(차량 행렬)
# 차량 행렬에 대해 교량이 이동하는 관점으로 접근
tws = [0] * w + tws + [0] * w  # 교량 인덱싱을 위해 차량 행렬 수정
idx, move_time = 0, 0
while idx < len(tws) - w:
    if sum(tws[idx + 1:idx + 1 + w]) <= L:  # 다음 차량으로 교량 이동이 가능할 경우
        idx += 1
    else:  # 다음 이동이 불가할 경우 교량 위 차량만 이동
        tws = tws[:idx + w] + [0] + tws[idx + w:]
        idx += 1
    move_time += 1
print(move_time)
