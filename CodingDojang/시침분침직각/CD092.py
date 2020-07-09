def main():
    count = 0
    for hh in range(24):
        for mm in range(60):
            if is_right_angle(hh, mm):
                print(f"{hh:0>2}:{mm:0>2}")
                count += 1
    print(count)


def is_right_angle(hh, mm):
    hh_ang = ((60 * hh + mm) * 0.5) % 360
    mm_ang = 6 * mm
    ang_diff = hh_ang - mm_ang
    if ang_diff < 0:
        ang_diff += 360

    delta = 3
    chk1 = 90 - delta < ang_diff < 90 + delta
    chk2 = 270 - delta < ang_diff < 270 + delta
    return chk1 or chk2


if __name__ == "__main__":
    main()
