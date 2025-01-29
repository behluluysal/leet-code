#include "pch.h"
#include "CppUnitTest.h"
#include "ListNode.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LeetCodeTestsCpp
{
    TEST_CLASS(LeetCodeTestsCpp)
    {
    public:

        TEST_METHOD(Test_DeleteMiddle_SingleElement)
        {
            ListNode* head = createLinkedList({ 1 });
            ListNode* result = deleteMiddle(head);
            Assert::IsNull(result, L"The result should be null after deleting the middle node in a single-element list.");
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_DeleteMiddle_TwoElementList)
        {
            ListNode* head = createLinkedList({ 1, 2 });
            ListNode* result = deleteMiddle(head);
            std::vector<int> output = linkedListToVector(result);
            std::vector<int> expected = { 1 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_DeleteMiddle_MultipleElementsOdd)
        {
            ListNode* head = createLinkedList({ 1, 2, 3, 4, 5 });
            ListNode* result = deleteMiddle(head);
            std::vector<int> output = linkedListToVector(result);
            std::vector<int> expected = { 1, 2, 4, 5 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_DeleteMiddle_MultipleElementsEven)
        {
            ListNode* head = createLinkedList({ 1, 2, 3, 4 });
            ListNode* result = deleteMiddle(head);
            std::vector<int> output = linkedListToVector(result);
            std::vector<int> expected = { 1, 2, 4 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_OddEvenList_EmptyList)
        {
            ListNode* head = nullptr;
            Assert::IsNull(oddEvenList(head));
        }

        TEST_METHOD(Test_OddEvenList_SingleElement)
        {
            ListNode* head = createLinkedList({ 1 });
            ListNode* result = oddEvenList(head);
            std::vector<int> output = linkedListToVector(result);

            std::vector<int> expected = { 1 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_OddEvenList_MultipleElements)
        {
            ListNode* head = createLinkedList({ 2, 1, 3, 5, 6, 4, 7 });
            ListNode* result = oddEvenList(head);
            std::vector<int> output = linkedListToVector(result);

            std::vector<int> expected = { 2, 3, 6, 7, 1, 5, 4 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }

        TEST_METHOD(Test_OddEvenList_AlreadySorted)
        {
            ListNode* head = createLinkedList({ 1, 2, 3, 4, 5 });
            ListNode* result = oddEvenList(head);
            std::vector<int> output = linkedListToVector(result);

            std::vector<int> expected = { 1, 3, 5, 2, 4 };
            Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
            for (size_t i = 0; i < output.size(); ++i) {
                Assert::AreEqual(expected[i], output[i], L"Element mismatch");
            }
            deleteLinkedList(result);
        }
    };
}
