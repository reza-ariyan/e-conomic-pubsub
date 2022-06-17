# E-Conomic PubSub
This project is a simple try to implement a PubSub pattern for both distributed and local publish and subscription that helps applications in an integration architecture to send messages to other applications that are subscirbed and are interested in those messages, without knowing the identity of the receivers


- Pub-sub pattern (image credit: [MSDN blog](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff649664(v=pandp.10)?redirectedfrom=MSDN))

    ![Schema](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/images/ff649664.despublishsubscribe_f01(en-us,pandp.10).gif)

### Usage
PubSub.Core makes it easy to implement a Pub-Sub pattern in your projects, you just need to create your project and reference PubSub.Core, then create your models as described below:
  
  - First ...