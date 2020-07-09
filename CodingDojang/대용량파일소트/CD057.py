import itertools
import heapq
import contextlib
import os


def main():
    inputfile = "./input.txt"  # 정렬할 파일 경로
    outputfile = "./output.txt"  # 정렬된 파일 경로
    seg_size = 5000  # 입력 파일에서 한 번에 읽어올 라인 수
    seg_files = []  # 부분 정렬된 파일의 목록

    with open(inputfile, "r") as fi:
        # seg_id: 부분 정렬된 파일을 저장할 식별자
        for seg_id in itertools.count(1):
            # 입력 파일로부터 seg_size 만큼씩 자료를 읽어서 정렬함
            partially_sorted = sorted(itertools.islice(fi, seg_size))
            if not partially_sorted:  # EOF
                break
            seg_file = f"./seg_{seg_id}.txt"  # 부분 정렬된 파일명
            seg_files.append(seg_file)
            with open(seg_file, "w") as fo:
                fo.writelines(partially_sorted)

    # https://stackoverflow.com/questions/26240228/how-to-join-multiple-sorted-files-in-python-alphabetically
    with contextlib.ExitStack() as stack:
        files = [stack.enter_context(open(seg_file)) for seg_file in seg_files]
        with open(outputfile, "w") as fo:
            fo.writelines(heapq.merge(*files))

    # 부분 정렬 파일 삭제
    for seg_file in seg_files:
        os.remove(seg_file)


if __name__ == "__main__":
    main()
