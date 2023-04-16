import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;

public class sticks extends JComponent {
    public static final int FIELD_EMPTY = 0;
    public static final int FIELD_X = 10;
    public static final int FIELD_O = 200;
    int[][] field;
    boolean isXturn;

    public sticks(){
        enableEvents(AWTEvent.MOUSE_EVENT_MASK);
        field = new int[5][5];
        //initGame();
    }
    public void initGame(){
        for(int i = 0; i<5;i++)
        {
            for(int j = 0; j< 5;i++)
            {
                field[i][j] = FIELD_EMPTY;
            }
        }
        isXturn = true;
    }
    public void mouseEntered(MouseEvent me) {
        // сохранить координаты
        mouseX = 0;
        mouseY = 10;
        msg = "Mouse entered."; // Курсор наведен
        repaint();
    }
    // обработать событие отведения курсора мыши
    public void mouseExited(MouseEvent me) {
        // сохранить координаты
        mouseX = 0;
        mouseY = 10;
        msg = "Mouse exited."; // Курсор отведен
        repaint();
    }
    protected void processMouseEvent(MouseEvent mouseEvent){
        super.processMouseEvent(mouseEvent);
        if(mouseEvent.getButton()==mouseEvent.BUTTON1){
            int x = mouseEvent.getX();
            int y = mouseEvent.getY();
            int i = (int)((float) x/ getWidth() * 5);
            int j = (int)((float) y/ getHeight() * 5);
            if(field[i][j] == FIELD_EMPTY)
            {
                field[i][j] = isXturn?FIELD_X:FIELD_O;
                isXturn = !isXturn;
                repaint();
            }
        }
    }


    protected void paintComponent(Graphics graphics){
        super.paintComponent(graphics);
        drawGrid(graphics);

    }
    void drawR(Graphics graphics){
        graphics.setColor(Color.RED);
        int number = 4;
        int w = getWidth();
        int h = getHeight();
        int dw = w/number;
        int dh = h/number;
        graphics.drawLine(dw,0,dh,0);
    }
    void drawGrid(Graphics graphics){
        int number = 5;
        int w = getWidth();
        int h = getHeight();
        int dw = w/number;
        int dh = h/number;
        Color newColor = new Color(135, 206, 250);
        graphics.setColor(newColor);
        for(int i = 1; i<number; i++)
        {
            graphics.drawLine(0,dh*i,w,dh*i);
            graphics.drawLine(dw*i,0,dw*i,h);
        }
    }
}
