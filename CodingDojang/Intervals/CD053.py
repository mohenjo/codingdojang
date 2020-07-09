def merge_sections(sections):
    sections.sort()
    merged = True
    while merged:
        merged = False
        for idx in range(len(sections) - 1):
            if sections[idx][1] >= sections[idx + 1][0]:
                hi = max(sections[idx][1], sections[idx + 1][1])
                sections[idx][1] = hi
                del sections[idx + 1]
                merged = True
                break


def main():
    size = int(input())
    sections = []
    for _ in range(size):
        section = list(map(int, input().split()))
        sections.append(section)

    merge_sections(sections)
    for section in sections:
        print(" ".join(map(str, section)))


if __name__ == '__main__':
    main()
