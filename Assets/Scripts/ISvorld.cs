using System;

public interface ISvorld
{
    event EventHandler OnSvorldSwing;

    void Atack();
    void AtackColiderTirnOff();
}