import matplotlib.pyplot as plt


# k = 5242888
# Read the values from the first text file
data = []
with open('100eksperiment_k=524288.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the first coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for sorterede estimater for k = 524288')

# Show the first plot
plt.show()


# Read the values from the second text file
data = []
with open('median_eksperiment_k=524288.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the second coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for usorterede estimater, median for k = 524288')

# Show the second plot
plt.show()

# k = 16384

# Read the values from the first text file
data = []
with open('100eksperiment_k=16384.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the first coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for sorterede estimater for k = 16384')

# Show the first plot
plt.show()



# Read the values from the second text file
data = []
with open('median_eksperiment_k=16384.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the second coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for usorterede estimater, median for k = 16384')

# Show the second plot
plt.show()


# k = 1024

# Read the values from the first text file
data = []
with open('100eksperiment_k=1024.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the first coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for sorterede estimater for k = 1024')

# Show the first plot
plt.show()



# Read the values from the second text file
data = []
with open('median_eksperiment_k=1024.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the second coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for usorterede estimater, median for k = 1024')

# Show the second plot
plt.show()

# k = 128

# Read the values from the first text file
data = []
with open('100eksperiment_k=128.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the first coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for sorterede estimater for k = 128')

# Show the first plot
plt.show()



# Read the values from the second text file
data = []
with open('median_eksperiment_k=128.txt', 'r') as file:
    for line in file:
        values = line.strip().split(',')
        x = int(values[0].strip('() '))
        y = int(values[1].strip('() '))
        data.append((x, y))

# Extract x and y values separately
x_values = [point[0] for point in data]
y_values = [point[1] for point in data]

# Plot the second coordinate system
plt.plot(x_values, y_values, 'bo-')  # 'bo-' for blue dots connected with a line
plt.axhline(y=961188, color='r', linestyle='--')  # Horizontal line

# Set axis labels and title
plt.xlabel('Antal eksperimenter')
plt.ylabel('Estimatorer')
plt.title('Resultat af eksperiment for usorterede estimater, median for k = 128')

# Show the second plot
plt.show()

