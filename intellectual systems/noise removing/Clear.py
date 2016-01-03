from PIL import Image, ImageDraw


def median_filter(img, out_img, window_size):
    if window_size % 2 == 0:
        return False
    pix = img.load()
    draw = ImageDraw.Draw(out_img)
    shift = window_size / 2
    for i in range(shift, width - shift):
        for j in range(shift, height - shift):
            red = []
            green = []
            blue = []
            for k in range(i - shift, i + shift + 1):
                for l in range(j - shift, j + shift + 1):
                    pixel = pix[k, l]
                    red.append(pixel[0])
                    green.append(pixel[1])
                    blue.append(pixel[2])

            median_index = window_size/2
            red.sort()
            green.sort()
            blue.sort()
            red_m = red[median_index]
            green_m = green[median_index]
            blue_m = blue[median_index]
            draw.point((i, j), (red_m, green_m, blue_m))
    return True


def linear_filter(img, out_img, window, window_size):
    if window_size % 2 == 0:
        return False
    pix = img.load()
    draw = ImageDraw.Draw(out_img)
    shift = window_size / 2
    for i in range(shift, width - shift):
        for j in range(shift, height - shift):

            red_sum = 0
            green_sum = 0
            blue_sum = 0
            for k in range(i - shift, i + shift + 1):
                for l in range(j - shift, j + shift + 1):
                    pixel = pix[k, l]
                    window_koef = window[i - k - shift][j - l - shift]
                    red_sum += pixel[0] * window_koef
                    green_sum += pixel[1] * window_koef
                    blue_sum += pixel[2] * window_koef

            draw.point((i, j), (int(red_sum), int(green_sum), int(blue_sum)))


def normalize_mask(mask, koef):
    size = mask.__len__()
    for i in range(size):
        for j in range(size):
            mask[i][j] *= koef
    return mask

path = "img3.jpg"
image = Image.open(path)
width = image.size[0]
height = image.size[1]
window_size = 3
ansImg = Image.new("RGB", (width, height), "white")

koef1 = 1.0/10.0
mask1 = [[1.0, 1.0, 1.0],
         [1.0, 2.0, 1.0],
         [1.0, 1.0, 1.0]]

koef2 = 1.0/16.0
mask2 = [[1.0, 2.0, 1.0],
         [2.0, 4.0, 2.0],
         [1.0, 2.0, 1.0]]

# norm_mask = normalize_mask(mask1, koef1)
norm_mask = normalize_mask(mask2, koef2)

linear_filter(image, ansImg, norm_mask, 3)
# median_filter(image, ansImg, window_size)

ansImg.save("ans3_linear_mask2.jpg", "JPEG")
