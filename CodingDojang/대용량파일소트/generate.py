import random


def main():
    size = 100_000
    min_val = 1_000_000
    max_val = min_val + size
    pool = [i for i in range(min_val, max_val)]
    random.shuffle(pool)

    path = "./input.txt"
    with open(path, "w") as f:
        for val in pool:
            f.write(f"{val}\n")


if __name__ == "__main__":
    main()
