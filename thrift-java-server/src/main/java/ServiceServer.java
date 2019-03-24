import com.LoginServiceImpl;
import com.service.impl.LoginService;
import org.apache.thrift.server.TServer;
import org.apache.thrift.server.TSimpleServer;
import org.apache.thrift.transport.TServerSocket;
import org.apache.thrift.transport.TServerTransport;
import org.apache.thrift.transport.TTransportException;

public class ServiceServer {
    private static TSimpleServer server;
    public static void main(String[] args) {

        try {
            start();
        } catch (TTransportException e) {
            e.printStackTrace();
        }
    }

    public static void start() throws TTransportException {
        System.out.print("Starting the server... ");
        TServerTransport serverTransport = new TServerSocket(9090);
        server = new TSimpleServer(new TServer.Args(serverTransport)
                .processor(new LoginService.Processor<>(new LoginServiceImpl())));
        server.serve();
        System.out.println("done.");
    }

    public static void stop() {
        if (server != null && server.isServing()) {
            System.out.print("Stopping the server... ");
            server.stop();
            System.out.println("done.");
        }
    }
}
