def main():
    numdoors = visits = 120
    doors = [False] * (numdoors + 1)

    count = 0
    for idx in range(1, numdoors + 1):
        for visit in range(1, visits + 1):
            if idx % visit == 0:
                doors[idx] = not doors[idx]
        if doors[idx]: count+= 1
    print(count)


if __name__ == "__main__":
    main()
