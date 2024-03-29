// Creating the OpenGL rendering window using GLFW - Learn OpenGL
// https://subscription.packtpub.com/book/game_development/9781789340365/1/ch01lvl1sec12/creating-the-opengl-rendering-window-using-glfw

#include <iostream>
#define GLEW_STATIC 
#include <GL/glew.h> 
#include <GLFW/glfw3.h>

// Window dimensions 
const GLint WIDTH = 800, HEIGHT = 600;

//LearnOpenGL - Hello Window
// https://learnopengl.com/Getting-started/Hello-Window
void processInput(GLFWwindow *window)
{
	if (glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
		glfwSetWindowShouldClose(window, true);
}

int main()
{
	std::cout << "Initializing\n";
	// Init GLFW 
	glfwInit();
	// Set all the required options for GLFW 
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);	// required in macOS
	glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);
	// Create a GLFWwindow object that we can use for GLFW's functions 
	GLFWwindow *window = glfwCreateWindow(WIDTH, HEIGHT, "LearnOpenGL", nullptr, nullptr);
	int screenWidth, screenHeight;
	glfwGetFramebufferSize(window, &screenWidth, &screenHeight);
	if (nullptr == window)
	{
		std::cout << "Failed to create GLFW window" << std::endl;
		glfwTerminate();

		return EXIT_FAILURE;
	}
	std::cout << "GLFW window created\n";
	glfwMakeContextCurrent(window);
	// Set this to true so GLEW knows to use a modern approach to retrieving function pointers and extensions 
	glewExperimental = GL_TRUE;
	// Initialize GLEW to setup the OpenGL Function pointers 
	if (GLEW_OK != glewInit())
	{
		std::cout << "Failed to initialize GLEW" << std::endl;
		return EXIT_FAILURE;
	}
	std::cout << "GLEW initialized\n";
	// Define the viewport dimensions 
	glViewport(0, 0, screenWidth, screenHeight);
	// Game loop 
	while (!glfwWindowShouldClose(window))
	{
		processInput(window);
		// Check if any events have been activiated (key pressed, 
		//mouse moved etc.) and call corresponding response functions 
		glfwPollEvents();
		// Render 
		// Clear the colorbuffer 
		glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);
		// Draw OpenGL 
		glfwSwapBuffers(window);
	}
	// Terminate GLFW, clearing any resources allocated by GLFW. 
	glfwTerminate();

	return EXIT_SUCCESS;
}
