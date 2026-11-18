import java.util.Objects;

/** Minimal zero-dependency test runner, so the exercise needs no downloads. */
final class Check {
    @FunctionalInterface
    interface TestBody {
        void run() throws Exception;
    }

    private static int failures = 0;

    static void test(String name, TestBody body) {
        try {
            body.run();
            System.out.println("PASS  " + name);
        } catch (Throwable t) {
            failures++;
            System.out.println("FAIL  " + name + "  ->  " + t);
        }
    }

    static void equal(Object expected, Object actual) {
        if (!Objects.equals(expected, actual)) {
            throw new AssertionError("expected <" + expected + "> but was <" + actual + ">");
        }
    }

    static void isTrue(boolean condition, String message) {
        if (!condition) {
            throw new AssertionError(message);
        }
    }

    static void finish() {
        System.out.println(failures == 0 ? "\nAll tests passed." : "\n" + failures + " test(s) failed.");
        if (failures > 0) {
            System.exit(1);
        }
    }
}
