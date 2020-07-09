def get_largest_subset(arr: list):
    max_subset = []
    cur_subset = []
    while arr:
        cur_val = min(arr)
        arr.pop(arr.index(cur_val))
        if cur_subset == [] or cur_val == cur_subset[-1] or cur_val == cur_subset[-1] + 1:
            cur_subset.append(cur_val)
            if len(cur_subset) > len(max_subset):
                max_subset = cur_subset
        else:
            cur_subset = [cur_val]

    return max_subset


def main():
    iarray = [1, 6, 10, 4, 7, 9, 5]
    rst = get_largest_subset(iarray)
    print(rst)


if __name__ == "__main__":
    main()
