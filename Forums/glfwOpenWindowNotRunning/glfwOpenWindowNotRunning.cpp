#include "pch.h"

int main()
{
    std::cout << "Hello World!\n";
	//mRunning = TRUE;
	//mRunning = FALSE;
	GLuint mRunning = GL_TRUE;
	if (glfwInit() == GL_FALSE) {
		MessageBox(NULL, "ERROR :: gagal menginisialisasi GLFW", "Error!", MB_OK);

		return(0);
	}
	if (glfwOpenWindow(640, 480, 0, 0, 0, 0, 24, 0, GLFW_WINDOW) == GL_FALSE) {
		MessageBox(NULL, "ERROR :: gagal membuat window", "Error!", MB_OK);
		glfwTerminate();
		return(0);
	}
	glfwSetWindowTitle("Praktikum Grafik Komputer LabTI");
	glfwSwapInterval(1);
	mulaiOpenGL();
	int r;
	while (mRunning) {
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glLoadIdentity();
		gluLookAt(10, 10, 10, 0, 0, 0, 0, 1, 0);
		glRotatef(r++, 0, 0, 1);
		glBegin(GL_TRIANGLES);
		glColor3f(1, 0, 0);
		glVertex3f(0, 5, 0);
		glVertex3f(4, 5, 0);
		glVertex3f(2, 0, 2);
		glColor3f(1, 0, 1);
		glVertex3f(4, 5, 0);
		glVertex3f(4, 5, 4);
		glVertex3f(2, 0, 2);
		glColor3f(1, 1, 0);
		glVertex3f(4, 5, 4);
		glVertex3f(0, 5, 4);
		glVertex3f(2, 0, 2);
		glColor3f(1, 1, 1);
		glVertex3f(0, 5, 4);
		glVertex3f(0, 5, 0);
		glVertex3f(2, 0, 2);
		glColor3f(1, 1, 1);
		glVertex3f(0, 5, 0);
		glVertex3f(4, 5, 0);
		glVertex3f(2, 10, 2);
		glColor3f(1, 0, 0);
		glVertex3f(4, 5, 0);
		glVertex3f(4, 5, 4);
		glVertex3f(2, 10, 2);
		glColor3f(1, 1, 1);
		glVertex3f(4, 5, 4);
		glVertex3f(0, 5, 4);
		glVertex3f(2, 10, 2);
		glColor3f(1, 1, 0);
		glVertex3f(0, 5, 4);
		glVertex3f(0, 5, 0);
		glVertex3f(2, 10, 2);
		glEnd();
		glfwSwapBuffers();
		mRunning = !glfwGetKey(GLFW_KEY_ESC) && glfwGetWindowParam(GLFW_OPENED);
	}
	glfwTerminate();
	return(0);
}

void mulaiOpenGL(void) {
	glViewport(0, 0, 640, 480);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60.0f, 640.0f / 480.0f, 0.1f, 1000.0f);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glShadeModel(GL_SMOOTH);
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
	glClearDepth(1.0f);
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LEQUAL);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
}
