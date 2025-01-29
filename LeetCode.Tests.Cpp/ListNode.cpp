#include "pch.h"
#include "ListNode.h"

ListNode* createLinkedList(const std::vector<int>& values) {
    if (values.empty()) return nullptr;
    ListNode* head = new ListNode(values[0]);
    ListNode* current = head;
    for (size_t i = 1; i < values.size(); ++i) {
        current->next = new ListNode(values[i]);
        current = current->next;
    }
    return head;
}

std::vector<int> linkedListToVector(ListNode* head) {
    std::vector<int> result;
    while (head) {
        result.push_back(head->val);
        head = head->next;
    }
    return result;
}

void deleteLinkedList(ListNode* head) {
    while (head) {
        ListNode* temp = head;
        head = head->next;
        delete temp;
    }
}

ListNode* deleteMiddle(ListNode* head) {
    ListNode* slow = head, * fast = head;
    if (!head->next) return nullptr;

    while (fast && fast->next) {
        fast = fast->next->next;
        if (!fast || !fast->next)
        {
            slow->next = slow->next->next;
            break;
        }
        slow = slow->next;
    }
    return head;
}

ListNode* oddEvenList(ListNode* head) {
    if (!head || !head->next) return head;

    ListNode* oddPtr = head;
    ListNode* evenPtr = head->next;
    ListNode* evenHead = head->next;
    while (evenPtr && evenPtr->next) {
        oddPtr->next = oddPtr->next->next;
        oddPtr = oddPtr->next;

        evenPtr->next = evenPtr->next->next;
        evenPtr = evenPtr->next;
    }
    oddPtr->next = evenHead;
    return head;
}