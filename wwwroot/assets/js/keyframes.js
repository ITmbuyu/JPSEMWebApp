@keyframes bounce {

    0 %,
        100 % {
            transform: translateY(0);
        }

    50 % {
        transform: translateY(-10px);
    }
}

@import url('https://fonts.googleapis.com/css?family=Cobalt&display=swap');

      body {
    font - family: 'Cobalt', sans - serif;
}

@keyframes bounceIn {

    from,
        20 %,
        40 %,
        60 %,
        80 %,
        to {
        -webkit - animation - timing - function: cubic- bezier(0.215, 0.610, 0.355, 1.000);
        animation - timing - function: cubic- bezier(0.215, 0.610, 0.355, 1.000);
    }

    0 % {
        opacity: 0;
        transform: scale3d(0.3, 0.3, 0.3);
    }

    20 % {
        transform: scale3d(1.1, 1.1, 1.1);
    }

    40 % {
        transform: scale3d(0.9, 0.9, 0.9);
    }

    60 % {
        opacity: 1;
        transform: scale3d(1.03, 1.03, 1.03);
    }

    80 % {
        transform: scale3d(0.97, 0.97, 0.97);
    }

          to {
        opacity: 1;
        transform: scale3d(1, 1, 1);
    }
}